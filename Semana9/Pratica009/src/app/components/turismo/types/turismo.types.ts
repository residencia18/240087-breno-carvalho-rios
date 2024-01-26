export type destination = {
    name: string,
    image: {
        url: string,
        alt: string
    },
    details: string[],
    price: {
        value: number,
        details: string[]
    }
}
