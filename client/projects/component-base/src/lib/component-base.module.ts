import { NgModule } from '@angular/core';
import { ComponentBaseComponent } from './component-base.component';
import { DashboardBaseComponent } from './controls/dashboard-base/dashboard-base.component';



@NgModule({
  declarations: [ComponentBaseComponent, DashboardBaseComponent],
  imports: [
  ],
  exports: [ComponentBaseComponent]
})
export class ComponentBaseModule { }
