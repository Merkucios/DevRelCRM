export interface CandidateData{
    logo: string;
    name: string;
    email: string;
    level?: string;
    lastEvent? : string;
    place? : number;
    date: string;
    contact?: string;
    git?: string;
    isLast: boolean;
    onEditClick: () => void;
}