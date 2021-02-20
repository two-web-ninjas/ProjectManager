import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'lib-component-ui',
  template: `
    <p>
      component-ui works!
    </p>
  `,
  styles: [
  ]
})
export class ComponentUiComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
