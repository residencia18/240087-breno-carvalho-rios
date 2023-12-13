// ...
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (g && (g = 0, op[0] && (_ = 0)), _) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var _a;
var WEATHER_API_KEY = "7d3187cad8f844b0ba805450231012";
var CURRENCY_API_KEY = "fca_live_mfcnOEpOKcv0bCuc6HpoHishYO7b7ntjUWI7ZhLH";
var NASA_API_KEY = "BRlZpq9k7zNO4SiegO3rhHudfmMJhMiTcXaKgxcQ";
var NEWS_API_KEY = "iaXOUw6l6solSkhKgY9ygTf3vZyT6cRvcbiG5RTa_MMmBF4A";
function getGeolocation() {
    return new Promise(function (resolve, reject) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                resolve({
                    lat: position.coords.latitude,
                    lon: position.coords.longitude
                });
            }, function (error) {
                reject(error);
            });
        }
        else {
            reject(new Error("Seu navegador não suporta geolocalização"));
        }
    });
}
function getWeather(coordParam) {
    return __awaiter(this, void 0, void 0, function () {
        var coords, response, json, error_1;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 4, , 5]);
                    return [4 /*yield*/, getGeolocation()];
                case 1:
                    coords = _a.sent();
                    if (coordParam) {
                        coords = coordParam;
                    }
                    return [4 /*yield*/, fetch("https://api.weatherapi.com/v1/current.json?key=".concat(WEATHER_API_KEY, "&q=").concat(coords.lat, ",").concat(coords.lon, "&aqi=no&lang=pt"))];
                case 2:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 3:
                    json = _a.sent();
                    return [2 /*return*/, json];
                case 4:
                    error_1 = _a.sent();
                    console.error(error_1);
                    if (error_1.code === error_1.PERMISSION_DENIED) {
                        alert("Este site utiliza localização para fornecer dados de clima, por favor, permita o acesso.");
                    }
                    throw error_1;
                case 5: return [2 /*return*/];
            }
        });
    });
}
function getCurrency() {
    return __awaiter(this, void 0, void 0, function () {
        var response, json, error_2;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 3, , 4]);
                    return [4 /*yield*/, fetch("https://api.freecurrencyapi.com/v1/latest?apikey=".concat(CURRENCY_API_KEY, "&currencies=USD%2CEUR&base_currency=BRL"))];
                case 1:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 2:
                    json = _a.sent();
                    return [2 /*return*/, json];
                case 3:
                    error_2 = _a.sent();
                    console.error(error_2);
                    throw error_2;
                case 4: return [2 /*return*/];
            }
        });
    });
}
function getNews() {
    return __awaiter(this, void 0, void 0, function () {
        var response, json, error_3;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 3, , 4]);
                    return [4 /*yield*/, fetch("https://api.currentsapi.services/v1/latest-news?apiKey=".concat(NEWS_API_KEY, "&category=academia"))];
                case 1:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 2:
                    json = _a.sent();
                    return [2 /*return*/, json];
                case 3:
                    error_3 = _a.sent();
                    console.error(error_3);
                    throw error_3;
                case 4: return [2 /*return*/];
            }
        });
    });
}
function getImageOfDay() {
    return __awaiter(this, void 0, void 0, function () {
        var today, yesterday, response, json, error_4;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 3, , 4]);
                    today = new Date();
                    yesterday = new Date();
                    yesterday.setDate(today.getDate() - 1);
                    return [4 /*yield*/, fetch("https://api.nasa.gov/planetary/apod?api_key=".concat(NASA_API_KEY, "&thumbs=true&start_date=").concat(yesterday.toISOString().slice(0, 10), "&end_date=").concat(today.toISOString().slice(0, 10)))];
                case 1:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 2:
                    json = _a.sent();
                    return [2 /*return*/, json];
                case 3:
                    error_4 = _a.sent();
                    console.error(error_4);
                    throw error_4;
                case 4: return [2 /*return*/];
            }
        });
    });
}
function getCountries(lang) {
    return __awaiter(this, void 0, void 0, function () {
        var response, json, error_5;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 3, , 4]);
                    return [4 /*yield*/, fetch("https://restcountries.com/v3.1/lang/".concat(lang))];
                case 1:
                    response = _a.sent();
                    return [4 /*yield*/, response.json()];
                case 2:
                    json = _a.sent();
                    return [2 /*return*/, json];
                case 3:
                    error_5 = _a.sent();
                    console.error(error_5);
                    throw error_5;
                case 4: return [2 /*return*/];
            }
        });
    });
}
function renderWeather() {
    return __awaiter(this, void 0, void 0, function () {
        var json, servicos, title, temperature, description, date, currentDate, error_6;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getWeather({ lat: -14.7980073, lon: -39.1763752 })];
                case 1:
                    json = _a.sent();
                    servicos = document.getElementById("weather-info");
                    if (servicos) {
                        title = servicos.querySelector('.service-title h2');
                        temperature = servicos.querySelector('#temperature');
                        description = servicos.querySelector('#weather-description');
                        date = servicos.querySelector('#date');
                        currentDate = new Date();
                        if (title && temperature && description && date) {
                            title.innerText = json.location.name;
                            temperature.innerText = "".concat(json.current.temp_c, "\u00B0C");
                            description.innerText = "".concat(json.current.condition.text.charAt(0).toUpperCase()).concat(json.current.condition.text.slice(1));
                            date.innerText = currentDate.toLocaleDateString();
                        }
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_6 = _a.sent();
                    console.error(error_6);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function renderUescWeather() {
    return __awaiter(this, void 0, void 0, function () {
        var json, servicos, title, temperature, description, date, currentDate, error_7;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getWeather({ lat: -14.7980073, lon: -39.1763752 })];
                case 1:
                    json = _a.sent();
                    servicos = document.getElementById("uesc-weather-info");
                    if (servicos) {
                        title = servicos.querySelector('.service-title h2');
                        temperature = servicos.querySelector('#temperature');
                        description = servicos.querySelector('#weather-description');
                        date = servicos.querySelector('#date');
                        currentDate = new Date();
                        if (title && temperature && description && date) {
                            title.innerText = "UESC";
                            temperature.innerText = "".concat(json.current.temp_c, "\u00B0C");
                            description.innerText = "".concat(json.current.condition.text.charAt(0).toUpperCase()).concat(json.current.condition.text.slice(1));
                            date.innerText = currentDate.toLocaleDateString();
                        }
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_7 = _a.sent();
                    console.error(error_7);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function renderCurrency() {
    return __awaiter(this, void 0, void 0, function () {
        var json, servicos, usd, eur, error_8;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getCurrency()];
                case 1:
                    json = _a.sent();
                    servicos = document.getElementById("currency-info");
                    if (servicos) {
                        usd = servicos.querySelector('#usd-brl-currency');
                        eur = servicos.querySelector('#eur-brl-currency');
                        usd.innerText = "".concat((1 / parseFloat(json.data.USD)).toFixed(2), " BRL");
                        eur.innerText = "".concat((1 / parseFloat(json.data.EUR)).toFixed(2), " BRL");
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_8 = _a.sent();
                    console.error(error_8);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function renderImageOfDay() {
    return __awaiter(this, void 0, void 0, function () {
        var json, destaques, i, div, h3, img, error_9;
        return __generator(this, function (_a) {
            switch (_a.label) {
                case 0:
                    _a.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getImageOfDay()];
                case 1:
                    json = _a.sent();
                    destaques = document.getElementById("destaques");
                    if (destaques) {
                        json = json.reverse();
                        for (i = 0; i < 2; i++) {
                            div = document.createElement("div");
                            h3 = document.createElement("h3");
                            img = document.createElement("img");
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
                    return [3 /*break*/, 3];
                case 2:
                    error_9 = _a.sent();
                    console.error(error_9);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function renderNews() {
    var _a;
    return __awaiter(this, void 0, void 0, function () {
        var json, news, i, notice, div, title, linkSpan, linkA, error_10;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0:
                    _b.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getNews()];
                case 1:
                    json = _b.sent();
                    news = (_a = document.getElementById('noticias')) === null || _a === void 0 ? void 0 : _a.querySelector(".card-body");
                    if (news) {
                        for (i = 0; i < 5; i++) {
                            notice = json.news[i];
                            div = document.createElement('div');
                            title = document.createElement('h3');
                            linkSpan = document.createElement('span');
                            linkA = document.createElement('a');
                            linkSpan.classList.add('news-link');
                            linkA.target = "_blank";
                            linkA.href = notice.url;
                            linkA.innerText = "Veja mais";
                            title.innerText = notice.title;
                            linkSpan.appendChild(linkA);
                            div.appendChild(title);
                            div.appendChild(linkSpan);
                            news.appendChild(div);
                        }
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_10 = _b.sent();
                    console.error(error_10);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
function renderCountries(lang) {
    var _a;
    return __awaiter(this, void 0, void 0, function () {
        var json, results, _i, json_1, country, div, error_11;
        return __generator(this, function (_b) {
            switch (_b.label) {
                case 0:
                    _b.trys.push([0, 2, , 3]);
                    return [4 /*yield*/, getCountries(lang)];
                case 1:
                    json = _b.sent();
                    results = (_a = document.getElementById('resultados')) === null || _a === void 0 ? void 0 : _a.querySelector("#paises");
                    if (results) {
                        results.innerHTML = "";
                        json.sort(function (a, b) { return a.translations.por.official.localeCompare(b.translations.por.official); });
                        for (_i = 0, json_1 = json; _i < json_1.length; _i++) {
                            country = json_1[_i];
                            div = document.createElement("div");
                            div.innerText = country.translations.por.official;
                            results.appendChild(div);
                        }
                    }
                    return [3 /*break*/, 3];
                case 2:
                    error_11 = _b.sent();
                    console.error(error_11);
                    return [3 /*break*/, 3];
                case 3: return [2 /*return*/];
            }
        });
    });
}
(_a = document.getElementById("linguagem")) === null || _a === void 0 ? void 0 : _a.addEventListener("change", function (event) {
    var element = event === null || event === void 0 ? void 0 : event.target;
    renderCountries(element.value);
});
window.addEventListener('load', function () {
    renderNews();
    renderWeather();
    renderUescWeather();
    renderCurrency();
    renderImageOfDay();
    renderCountries("portuguese");
});
