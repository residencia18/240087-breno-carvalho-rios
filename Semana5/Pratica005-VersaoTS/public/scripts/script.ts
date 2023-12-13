// ...

const WEATHER_API_KEY: string = "7d3187cad8f844b0ba805450231012";
const CURRENCY_API_KEY: string = "fca_live_mfcnOEpOKcv0bCuc6HpoHishYO7b7ntjUWI7ZhLH";
const NASA_API_KEY: string = "BRlZpq9k7zNO4SiegO3rhHudfmMJhMiTcXaKgxcQ";
const NEWS_API_KEY: string = "iaXOUw6l6solSkhKgY9ygTf3vZyT6cRvcbiG5RTa_MMmBF4A";

interface Coordinates {
  lat: number;
  lon: number;
}

interface WeatherData {
  location: {
    name: string;
  };
  current: {
    temp_c: number;
    condition: {
      text: string;
    };
  };
}

function getGeolocation(): Promise<Coordinates> {
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

async function getWeather(coordParam?: Coordinates): Promise<WeatherData> {
  try {
    let coords: Coordinates = await getGeolocation();
    if (coordParam) {
      coords = coordParam;
    }
    const response = await fetch(
      `https://api.weatherapi.com/v1/current.json?key=${WEATHER_API_KEY}&q=${coords.lat},${coords.lon}&aqi=no&lang=pt`
    );
    const json: WeatherData = await response.json();
    return json;
  } catch (error: any) {
    console.error(error);
    if (error.code === error.PERMISSION_DENIED) {
      alert("Este site utiliza localização para fornecer dados de clima, por favor, permita o acesso.");
    }
    throw error;
  }
}

async function getCurrency(): Promise<any> {
  try {
    const response = await fetch(`https://api.freecurrencyapi.com/v1/latest?apikey=${CURRENCY_API_KEY}&currencies=USD%2CEUR&base_currency=BRL`);
    const json = await response.json();
    return json;
  } catch (error) {
    console.error(error);
    throw error;
  }
}

async function getNews(): Promise<any> {
  try {
    const response = await fetch(`https://api.currentsapi.services/v1/latest-news?apiKey=${NEWS_API_KEY}&category=academia`);
    const json = await response.json();
    return json;
  } catch (error) {
    console.error(error);
    throw error;
  }
}

async function getImageOfDay(): Promise<any> {
  try {
    let today = new Date();
    let yesterday = new Date();
    yesterday.setDate(today.getDate() - 1);

    const response = await fetch(`https://api.nasa.gov/planetary/apod?api_key=${NASA_API_KEY}&thumbs=true&start_date=${yesterday.toISOString().slice(0, 10)}&end_date=${today.toISOString().slice(0, 10)}`);
    const json = await response.json();
    return json;
  } catch (error) {
    console.error(error);
    throw error;
  }
}

async function getCountries(lang: string): Promise<any> {
  try {
    const response = await fetch(`https://restcountries.com/v3.1/lang/${lang}`);
    const json = await response.json();
    return json;
  } catch (error) {
    console.error(error);
    throw error;
  }
}

async function renderWeather() {
  try {
    const json = await getWeather({ lat: -14.7980073, lon: -39.1763752 });

    const servicos = document.getElementById("weather-info");
    if (servicos) {
      const title = servicos.querySelector('.service-title h2') as HTMLHeadingElement;
      const temperature = servicos.querySelector('#temperature') as HTMLElement;
      const description = servicos.querySelector('#weather-description') as HTMLElement;
      const date = servicos.querySelector('#date') as HTMLElement;
      const currentDate = new Date();

      if (title && temperature && description && date) {
        title.innerText = json.location.name;
        temperature.innerText = `${json.current.temp_c}°C`;
        description.innerText = `${json.current.condition.text.charAt(0).toUpperCase()}${json.current.condition.text.slice(1)}`;
        date.innerText = currentDate.toLocaleDateString();
      }
    }
  } catch (error) {
    console.error(error);
  }
}

async function renderUescWeather() {
  try {
    const json = await getWeather({ lat: -14.7980073, lon: -39.1763752 });

    const servicos = document.getElementById("uesc-weather-info");
    if (servicos) {
      const title = servicos.querySelector('.service-title h2') as HTMLHeadingElement;
      const temperature = servicos.querySelector('#temperature') as HTMLElement;
      const description = servicos.querySelector('#weather-description') as HTMLElement;
      const date = servicos.querySelector('#date') as HTMLElement;
      const currentDate = new Date();

      if (title && temperature && description && date) {
        title.innerText = "UESC";
        temperature.innerText = `${json.current.temp_c}°C`;
        description.innerText = `${json.current.condition.text.charAt(0).toUpperCase()}${json.current.condition.text.slice(1)}`;
        date.innerText = currentDate.toLocaleDateString();
      }
    }
  } catch (error) {
    console.error(error);
  }
}


async function renderCurrency(): Promise<void> {
  try {
    const json = await getCurrency();

    const servicos = document.getElementById("currency-info");
    if (servicos) {
      const usd = servicos.querySelector('#usd-brl-currency') as HTMLElement;
      const eur = servicos.querySelector('#eur-brl-currency') as HTMLElement;

      usd.innerText = `${(1 / parseFloat(json.data.USD)).toFixed(2)} BRL`;
      eur.innerText = `${(1 / parseFloat(json.data.EUR)).toFixed(2)} BRL`;
    }
  } catch (error) {
    console.error(error);
  }
}

async function renderImageOfDay(): Promise<void> {
  try {
    let json = await getImageOfDay();

    const destaques = document.getElementById("destaques");
    if (destaques) {
      json = json.reverse();
      for (let i = 0; i < 2; i++) {
        const div = document.createElement("div");
        const h3 = document.createElement("h3");
        const img = document.createElement("img");

        img.src = json[i].url;
        if (json[i].media_type === "video") {
          img.src = json[i].thumbnail_url;
        }
        h3.innerText = json[i].title;
        img.alt = json[i].title;

        div.appendChild(h3);
        div.appendChild(img);
        destaques.appendChild(div);
      }
    }
  } catch (error) {
    console.error(error);
  }
}

async function renderNews(): Promise<void> {
  try {
    const json = await getNews();

    const news = document.getElementById('noticias')?.querySelector(".card-body");
    if (news) {
      for (let i = 0; i < 5; i++) {
        const notice = json.news[i];
        const div = document.createElement('div');
        const title = document.createElement('h3');
        const linkSpan = document.createElement('span');
        const linkA = document.createElement('a');

        linkSpan.classList.add('news-link');
        linkA.target = "_blank";

        linkA.href = notice.url;
        linkA.innerText = `Veja mais`;
        title.innerText = notice.title;

        linkSpan.appendChild(linkA);
        div.appendChild(title);
        div.appendChild(linkSpan);
        news.appendChild(div);
      }
    }
  } catch (error) {
    console.error(error);
  }
}

async function renderCountries(lang: string): Promise<void> {
  try {
    const json = await getCountries(lang);

    const results = document.getElementById('resultados')?.querySelector("#paises");
    if (results) {
      results.innerHTML = "";
      json.sort((a: any, b: any) => a.translations.por.official.localeCompare(b.translations.por.official));
      for (const country of json) {
        const div = document.createElement("div");
        div.innerText = country.translations.por.official;
        results.appendChild(div);
      }
    }
  } catch (error) {
    console.error(error);
  }
}


document.getElementById("linguagem")?.addEventListener("change", (event) => {
    const element = event?.target as HTMLSelectElement;
    renderCountries(element.value);
});

window.addEventListener('load', () => {
    renderNews();
    renderWeather();
    renderUescWeather();
    renderCurrency();
    renderImageOfDay();
    renderCountries("portuguese");
});