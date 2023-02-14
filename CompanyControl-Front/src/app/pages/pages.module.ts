import { NgModule } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatCardModule} from '@angular/material/card';
import { ReactiveFormsModule } from '@angular/forms';
import {MatDialogModule} from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CompanyComponent } from './company/company.component';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { DetailsCompanyComponent } from './company/details-company/details-company.component';
import { RouterModule } from '@angular/router';
import {MatTooltipModule} from '@angular/material/tooltip';

@NgModule({
  declarations: [
    CompanyComponent,
    DetailsCompanyComponent
  ],
  imports: [
    MatToolbarModule,
    MatCardModule,
    CommonModule,
    MatFormFieldModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
    RouterModule,
    MatTooltipModule
  ],
  exports: [
    MatFormFieldModule,
    MatDialogModule
  ]
})
export class PagesModule { }
