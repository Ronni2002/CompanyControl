import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CompanyModel } from 'src/app/models/company.model';
import { CustomerModel } from 'src/app/models/customer.model';
import { CompanyService } from 'src/app/services/company.service';
import { CustomerService } from 'src/app/services/customer.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-details-company',
  templateUrl: './details-company.component.html',
  styleUrls: ['./details-company.component.scss']
})
export class DetailsCompanyComponent implements OnInit {

  companies: CompanyModel = {} as CompanyModel
  formCreate!: FormGroup;
  id!: string 
  costumer: CustomerModel = {} as CustomerModel
  constructor(private route: ActivatedRoute, private serviceComapy: CompanyService, private service:CustomerService,  private _fb: FormBuilder) { }

  ngOnInit(): void {
    this.buildCreateForm()
    this.getRouterId()
  }

  buildCreateForm() {
    this.formCreate = this._fb.group({
      name: ['', Validators.required],
      lastName: ['', Validators.required],
      age: [0, Validators.required],
      companyId: [this.id, Validators.required],
      addresses: this._fb.array([this.createNewRefence()]),
    });
  }

  public get addresses() {
    return this.formCreate.get('addresses') as FormArray;
  }

  getCompanyById(id:string) {
    this.serviceComapy.getById(id).subscribe({
      next: (companies) => {
        this.companies = companies;
      },
      error: (err)=> {
      }
    })
  }

  getRouterId(){
    this.route.params.subscribe(params => {
      this.id = params["id"]
      this.getCompanyById(this.id)
    })
  }

  createCompany(){
    this.formCreate.value['companyId'] = this.id
    this.formCreate.value['addresses'] = this.formCreate.value['addresses'].map((address: any) => {
        return address.adress
    })
    this.service.post(this.formCreate.value).subscribe(data => {
      Swal.fire("Exitoso","Customer save success",'success')
      this.getRouterId()
    })
  }

  createNewRefence() {
    return this._fb.group({
      id: [0, Validators.required],
      adress: ['', [Validators.required]],
    });
  }

  public addNewAddress() {
    this.addresses.push(this.createNewRefence());
  }

  public removeNewAddress(i: number) {
    this.addresses.removeAt(i);
  }

  public deleteCustomer(id: string){
    this.service.delete(id).subscribe({
      next: () => {
        Swal.fire({
          title: 'Quieres eliminar este registro?',
          text: "Al aceptar confirmas eliminar este registro",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Si, eliminar'
        }).then((result) => {
          if (result.isConfirmed) {
            Swal.fire(
              'Deleted!',
              'Your file has been deleted.',
              'success'
            )
            this.getCompanyById(this.id)
          }
        })
      },
      error: (err)=> {
      }
    })
  }

  getCustomerById(id: string){
    this.service.getById(id).subscribe({
      next: (costumer) => {
        this.costumer = costumer;
      },
      error: (err)=> {
      }
    })
  }

}
