import { Component, OnInit } from '@angular/core';
import {RegistrationBaseComponent} from '@project-manager/component-base';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent extends RegistrationBaseComponent implements OnInit {

  constructor() {
    super();
  }

  ngOnInit(): void {
  }

}
