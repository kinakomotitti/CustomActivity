namespace CustomActivity
{
    #region usging
    using System.Activities;
    using System.ComponentModel;
    #endregion

    [Designer(typeof(ActivityDesigner1))] //デザイナーとコードを紐づける。
    public sealed class CodeClassName : CodeActivity //このクラス名がアクティビティ名になる
    {
        [Category("Input")] //※ワークフローから与えられるパラメータはInArgument<T>で設定する
        [RequiredArgument]
        public InArgument<string> Input { get; set; }

        //※失敗したパターン
        //String型のプロパティとして変数を定義すると、ワークフローから”変数”を指定することができなくなる
        public string Parameter { get; set; } = "Default Parameter";


        [Category("Output")]//※ワークフローへ返却するパラメータはOutArgument<T>で設定する
        public OutArgument<string> Output { get; set; }//※どの値が返却されるかわからないと使いにくい。わかりやすい名前を付けるべき。

        protected override void Execute(CodeActivityContext context)
        {
            var firstNumber = Input.Get(context);
            Output.Set(context, 1);
        }
    }
}
