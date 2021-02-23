import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComponentUiComponent } from './component-ui.component';

describe('ComponentUiComponent', () => {
  let component: ComponentUiComponent;
  let fixture: ComponentFixture<ComponentUiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComponentUiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComponentUiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
