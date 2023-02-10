import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-filterByProductCodeModal',
  templateUrl: './filterByProductCodeModal.component.html',
  styleUrls: ['./filterByProductCodeModal.component.scss']
})
export class FilterByProductCodeModalComponent implements OnInit {


  filterForm: FormGroup;
  constructor(private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.filterForm = this.formBuilder.group({
      productcode:['',[Validators.required]]
    });
  }
  close()
  {
    this.activeModal.close();
  }
  search()
  {
    this.filterForm.markAllAsTouched();
    if(this.filterForm.valid)
    {
        this.activeModal.close(this.filterForm.controls["productcode"].value);
    }
  }
}
