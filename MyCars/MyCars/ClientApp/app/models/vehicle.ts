
export interface KeyValuePair {
    id: number; 
    name: string 
}

export interface Contact {
    name: string; 
    phone: string;
    email: string;
}

export interface Vehicle {
    id: number;
    model: KeyValuePair;
    make: KeyValuePair;
    isOwned : boolean;
    features : KeyValuePair[];
    contact: Contact;
    lastUpdate: string;
}

export interface SaveVehicle {
    id: number;
    modelId: number;
    makeId: number;
    isOwned : boolean;
    features : number[];
    contact: Contact;    
}