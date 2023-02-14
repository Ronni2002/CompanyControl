import { CustomerModel } from "./customer.model";

export interface CompanyModel {
    id: string;
    name: string;
    shortName: string;
    rnc: number;
    customers: CustomerModel[]
}