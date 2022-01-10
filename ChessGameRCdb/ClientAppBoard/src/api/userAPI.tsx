export const userAPI = {
    async fetchById(id: string) {
        return new Promise<{ data: number }>(resolve =>
            fetch(`api/MoveAnalysis/GetBoard`).then(response => response.json() as Promise<WeatherForecast[]>).then((d) => resolve({ data: 1}))
        )
    }
}

export const timeout = {
    async fetchById(id: string) {
        return new Promise<{ data: number }>(resolve =>
            setTimeout(() => {
                resolve({ data: 1 })
            }, 4000),
        )
    },
}

export interface WeatherForecast {
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}