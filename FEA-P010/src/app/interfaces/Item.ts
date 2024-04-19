export interface Item {
    id: number;
    name: string;
    price: number;
    inStock: boolean,
    properties?: {
        color: string,
        capacity: string,
        style: string,
    }
    imageURL: string;
}
