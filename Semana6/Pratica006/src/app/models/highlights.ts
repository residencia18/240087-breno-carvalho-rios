export interface Highlight {
    title: string;
    url: string;
    thumbnail_url: string;
    media_type: string;
    explanation: string;
}

export interface HilightsResponse {
    highlights: Highlight[]
}
