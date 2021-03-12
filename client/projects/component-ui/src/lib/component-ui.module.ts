import { NgModule } from '@angular/core';
import { DashboardComponent } from './controls/dashboard/dashboard.component';
import { RegistrationComponent } from './controls/registration/registration.component';

@NgModule({
  declarations: [ DashboardComponent, RegistrationComponent ],
  imports: [
  ],
  exports: [ DashboardComponent, RegistrationComponent ]
})
export class ComponentUiModule { }
