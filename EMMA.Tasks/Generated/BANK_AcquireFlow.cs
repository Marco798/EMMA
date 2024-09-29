namespace EMMA.Tasks {
	internal partial class BANK_AcquireFlow : MainTask {
		public new InputParams inputParams;

		public BANK_AcquireFlow() {
			inputParams = new();
		}

		public override void SetInputParams(IInputParams inputParams) {
			inputParams = (InputParams)inputParams;
		}

		public static void RunTask(InputParams inputParams) {
			RunTask<BANK_AcquireFlow>(inputParams);
		}

		public new class InputParams : IInputParams {
			public string? FileName { get; set; }
		}
	}
}
