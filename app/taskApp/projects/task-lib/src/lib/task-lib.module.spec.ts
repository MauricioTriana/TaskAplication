
    import { async, TestBed } from '@angular/core/testing';
    import { TaskLibModule } from './task-lib.module';
    
    describe('TaskLibModule', () => {
      beforeEach(async(() => {
        TestBed.configureTestingModule({
          imports: [ TaskLibModule ]
        })
        .compileComponents();
      }));
    
      // TODO: Add real tests here.
      //
      // NB: This particular test does not do anything useful. 
      //     It does NOT check for correct instantiation of the module.
      it('should have a module definition', () => {
        expect(TaskLibModule).toBeDefined();
      });
    });
          