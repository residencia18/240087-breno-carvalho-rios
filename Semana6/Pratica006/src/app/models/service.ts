export interface CurrenciesResponse {
    data: {
        [key: string]: string
    }
}

export interface Location {
    name: string;
    region: string;
}

export interface Weather {
    condition: any;
    temp_c: string;
    feelslike_c: string;
    wind_kph: string;
    last_updated: string;
}

export interface WeatherResponse {
    location: Location,
    current: Weather
}
