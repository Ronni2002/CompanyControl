import { Component, OnInit } from '@angular/core';
import { CompanyModel } from 'src/app/models/company.model';
import { CompanyService } from 'src/app/services/company.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.scss']
})
export class CompanyComponent implements OnInit {

  formCreate!: FormGroup;
  companies: CompanyModel[] = [];
  company : CompanyModel = {} as CompanyModel

  constructor(private service: CompanyService, private _fb: FormBuilder) { }

  ngOnInit(): void {
    this.buildCreateForm()
    this.getAll()
  }

  buildCreateForm() {
    this.formCreate = this._fb.group({
      name: ['', Validators.required],
      shortName: ['', Validators.required],
      rnc: [0, Validators.required]
    });
  }

  getAll(){
    this.service.getAll().subscribe((companies: CompanyModel[]) => {
        this.companies = companies;
    })
  }

  createCompany(){
    debugger
    this.service.post(this.formCreate.value).subscribe(data => {
      Swal.fire("Exitoso","Company save success",'success')
      this.getAll()
    })
  }

  public deleteCompany(id: string){
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
            this.getAll()
          }
        })
      },
      error: (err)=> {
      }
    })
  }

}
