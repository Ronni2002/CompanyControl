import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends BaseService<CustomerModel> {
  constructor(http: HttpClient){
    super(http,'Customer')
  }
}
