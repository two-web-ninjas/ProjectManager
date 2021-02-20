import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-component-base',
  template: `
    <p>
      component-base works!
    </p>
  `,
  styles: [
  ]
})
export class ComponentBaseComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
