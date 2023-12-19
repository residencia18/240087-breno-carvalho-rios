export interface Noticia {
    id: number;
    title: string;
    url: string;
}

export interface NoticiasResponse {
    status: string,
    news: Noticia[]
  }