import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CompanyModel } from '../models/company.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class CompanyService extends BaseService<CompanyModel> {
  constructor(http: HttpClient){
    super(http,'Company')
  }
}
