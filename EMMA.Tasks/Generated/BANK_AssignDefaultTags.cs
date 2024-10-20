namespace EMMA.Tasks {
    internal partial class BANK_AssignDefaultTags : MainTask {
        public new InputParams inputParams;

        public BANK_AssignDefaultTags() {
            inputParams = new();
        }

        public override void SetInputParams(IInputParams inputParams) {
            inputParams = (InputParams)inputParams;
        }

        public static void RunTask(InputParams inputParams) {
            RunTask<BANK_AssignDefaultTags>(inputParams);
        }

        public new class InputParams : IInputParams {

        }
    }
}
