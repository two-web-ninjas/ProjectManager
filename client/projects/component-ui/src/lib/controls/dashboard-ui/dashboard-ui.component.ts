import { Component, OnInit } from '@angular/core';
import { DashboardBaseComponent } from '@project-manager/component-base';

@Component({
  selector: 'lib-dashboard-ui',
  templateUrl: './dashboard-ui.component.html',
  styleUrls: ['./dashboard-ui.component.css']
})
export class DashboardUiComponent extends DashboardBaseComponent implements OnInit {

  constructor() {
    super()
  }

  ngOnInit(): void {
  }

}
