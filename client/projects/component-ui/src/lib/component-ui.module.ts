import { NgModule } from '@angular/core';
import { ComponentUiComponent } from './component-ui.component';
import { DashboardUiComponent } from './controls/dashboard-ui/dashboard-ui.component';



@NgModule({
  declarations: [ComponentUiComponent, DashboardUiComponent],
  imports: [
  ],
  exports: [ComponentUiComponent]
})
export class ComponentUiModule { }
