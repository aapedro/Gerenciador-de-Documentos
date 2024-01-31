export enum DocumentStatus {
    PENDING = 0,
    APPROVED = 1,
    DENIED = 2,
}

export interface Document {
    id: number;
    name: string;
    fileName: string;
    description: string;
    status: DocumentStatus;
}