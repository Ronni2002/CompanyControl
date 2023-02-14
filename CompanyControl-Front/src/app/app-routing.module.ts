import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyComponent } from './pages/company/company.component';
import { DetailsCompanyComponent } from './pages/company/details-company/details-company.component';

const routes: Routes = [
  { path: 'company', component: CompanyComponent},
  { path: '', redirectTo: 'company', pathMatch: 'full'},
  {path: 'company/:id' , component: DetailsCompanyComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
