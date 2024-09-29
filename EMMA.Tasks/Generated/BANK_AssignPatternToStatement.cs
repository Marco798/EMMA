namespace EMMA.Tasks {
	internal partial class BANK_AssignPatternToStatement : MainTask {
		public new InputParams inputParams;

		public BANK_AssignPatternToStatement() {
			inputParams = new();
		}

		public override void SetInputParams(IInputParams inputParams) {
			inputParams = (InputParams)inputParams;
		}

		public static void RunTask(InputParams inputParams) {
			RunTask<BANK_AssignPatternToStatement>(inputParams);
		}

		public new class InputParams : IInputParams {

		}
	}
}
