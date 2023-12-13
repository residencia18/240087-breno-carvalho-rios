const WEATHER_API_KEY = "7d3187cad8f844b0ba805450231012";
const CURRENCY_API_KEY = "fca_live_mfcnOEpOKcv0bCuc6HpoHishYO7b7ntjUWI7ZhLH";
const NASA_API_KEY = "BRlZpq9k7zNO4SiegO3rhHudfmMJhMiTcXaKgxcQ";
const NEWS_API_KEY = "iaXOUw6l6solSkhKgY9ygTf3vZyT6cRvcbiG5RTa_MMmBF4A";

function getGeolocation() {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve({
                        lat: position.coords.latitude,
                        lon: position.coords.longitude
                    });
                },
                (error) => {
                    reject(error);
                }
            );
        } else {
            reject(new Error("Seu navegador não suporta geolocalização"));
        }
    });
}

async function getWeather(coordParam) {
    try {
        let coords = await getGeolocation();
        if(coordParam) {
            coords = coordParam;
        }
        const response = await fetch(`https://api.weatherapi.com/v1/current.json?key=${WEATHER_API_KEY}&q=${coords.lat},${coords.lon}&aqi=no&lang=pt`);
        const json = await response.json();
        return json;
    } catch (error) {
        console.error(error);
        if (error.code === error.PERMISSION_DENIED) {
            alert("Este site utiliza localização para fornecer dados de clima, por favor, permita o acesso.");
        }
    }
}

async function getCurrency() {
    return new Promise((resolve, reject) => {
        fetch(`https://api.freecurrencyapi.com/v1/latest?apikey=${CURRENCY_API_KEY}&currencies=USD%2CEUR&base_currency=BRL`)
            .then(response => response.json())
            .then(json => {
                resolve(json);
            })
            .catch(error => {
                reject(error);
            });
    });
}

async function getNews() {
    return new Promise((resolve, reject) => {
        fetch(`https://api.currentsapi.services/v1/search?apiKey=${NEWS_API_KEY}&category=academia`)
            .then(json => {
                resolve(json);
            })
            .catch(error => {
                reject(error);
            });
    });
}

async function getImageOfDay() {
    let today = new Date();
    let yesterday = new Date();
    yesterday.setDate(today.getDate() - 1);

    return new Promise((resolve, reject) => {
        fetch(`https://api.nasa.gov/planetary/apod?api_key=${NASA_API_KEY}&thumbs=true&start_date=${yesterday.toISOString().slice(0, 10)}&end_date=${today.toISOString().slice(0, 10)}`)
            .then(response => response.json())
            .then(json => {
                resolve(json);
            })
            .catch(error => {
                reject(error);
            });
    });
}

async function getCountries(lang) {
    return new Promise((resolve, reject) => {
        fetch(`https://restcountries.com/v3.1/lang/${lang}`)
            .then(response => response.json())
            .then(json => {
                resolve(json);
            })
            .catch(error => {
                reject(error);
            });
    });
}

function renderWeather() {
    getWeather().then((json) => {
        let servicos = document.getElementById("weather-info");
        let title = servicos.querySelector('.service-title h2');
        let temperature = servicos.querySelector('#temperature');
        let description = servicos.querySelector('#weather-description');
        let date = servicos.querySelector('#date');
        let currentDate = new Date();
        title.innerText = json.location.name;
        temperature.innerText = json.current.temp_c + "°C";
        description.innerText = json.current.condition.text.charAt(0).toUpperCase() + json.current.condition.text.slice(1);
        date.innerText = currentDate.toLocaleDateString();
    })
}

function renderUescWeather() {
    getWeather({lat: -14.7980073, lon: -39.1763752}).then((json) => {
        let servicos = document.getElementById("uesc-weather-info");
        let title = servicos.querySelector('.service-title h2');
        let temperature = servicos.querySelector('#temperature');
        let description = servicos.querySelector('#weather-description');
        let date = servicos.querySelector('#date');
        let currentDate = new Date();
        title.innerText = "UESC";
        temperature.innerText = json.current.temp_c + "°C";
        description.innerText = json.current.condition.text.charAt(0).toUpperCase() + json.current.condition.text.slice(1);
        date.innerText = currentDate.toLocaleDateString();
    })
}

function renderCurrency() {
    getCurrency().then((json) => {
        let servicos = document.getElementById("currency-info");
        let usd = servicos.querySelector('#usd-brl-currency');
        let eur = servicos.querySelector('#eur-brl-currency');
        
        usd.innerText = `${(1 / parseFloat(json.data.USD)).toFixed(2)} BRL`;
        eur.innerText = `${(1 / parseFloat(json.data.EUR)).toFixed(2)} BRL`;
    })
}

function renderImageOfDay() {
    getImageOfDay().then((json) => {
        let destaques = document.getElementById("destaques");
        json = json.reverse();
        for (let i = 0; i < 2; i++) {
            let div = document.createElement("div");
            let h3 = document.createElement("h3");
            let img = document.createElement("img");

            img.src = json[i].url;
            if(json[i].media_type === "video") {
                img.src = json[i].thumbnail_url;
            }
            h3.innerText = json[i].title;
            img.alt = json[i].title;

            div.appendChild(h3);
            div.appendChild(img);
            destaques.appendChild(div);
        }
    });
}

function renderNews() {
    getNews().then((json) => {
        let news = document.getElementById('noticias').querySelector(".card-body");
        for (let i = 0; i < 5; i++){
            console.log(json)
            let notice = json.news[i];
            let div = document.createElement('div');
            let title = document.createElement('h3');
            let linkSpan = document.createElement('span');
            let linkA = document.createElement('a');

            linkSpan.classList.add('news-link')
            linkA.target = "_blank";

            linkA.href = notice.url;
            linkA.innerText = `Veja mais`;
            title.innerText = notice.title;

            linkSpan.appendChild(linkA);
            div.appendChild(title);
            div.appendChild(linkSpan);
            news.appendChild(div);
        }
    })
}

function renderCountries(lang) {
    getCountries(lang).then((json) => {
        let results = document.getElementById('resultados').querySelector("#paises");
        results.innerHTML = "";
        json.sort((a, b) => a.translations.por.official.localeCompare(b.translations.por.official));
        for (country of json){
            let div = document.createElement("div");
            div.innerText = country.translations.por.official;
            results.appendChild(div);
        }
    })
}

document.getElementById("linguagem").addEventListener("change", (event) => {
    renderCountries(event.target.value);
});

window.addEventListener('load', () => {
    renderNews();
    renderWeather({lat: -22.9035, lon: -43.2096});
    renderUescWeather();
    renderCurrency();
    renderImageOfDay();
    renderCountries("portuguese");
});