using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EbSite.Base.BLL;
using EbSite.Base.ControlPage;
using EbSite.Base.Modules;

namespace EbSite.Modules.Exam.AdminPages.Controls.Exam
{
    public partial class QuestionsAdd : MPUCBaseSave
    {

       
       //每个选项选中时的值
       public string AswersdB = "B";
       public string AswersdC = "C";
       public string AswersdD = "D";
       public string AswersdE = "E";
       public string AswersdF = "F";
       public string AswersdG = "G";
       public string AswersdA = "A";

        override public Guid ModuleMenuID
        {
            get
            {
                return new Guid("46f5b5e1-fd20-4dde-b0ed-1b8088672e6b");
            }
        }
        private int GetInationID
        {
            get { return Core.Utils.StrToInt(Request["iid"],0); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BLL.exam_ination.Instance.GetEntity(GetInationID);
                lbInation.ForeColor = Color.Brown;
                lbInation.Text = Request["title"];
              
                //页面加载时
                //QuestionsType.SelectedValue ="0";
                 
                 
            }
            ctbTag.Items = string.Format("编辑考题#tg1|设置答案#tg2");//设置标签切换项
            ctbTag.EndLiteral = llTagEnd;//设置结束标记控件
        }
        public override string PageName
        {
            get
            {
                return "编辑考题";
            }
        }
        public override string Permission
        {
            get
            {
                return "1";
            }
        }
        override protected string KeyColumnName
        {
            get
            { 
                return "id";
            }
        }
        protected override void OnBasePageLoading()
        {
            ClassID.DataValueField = "id";
            ClassID.DataTextField = "ClassName";
            ClassID.DataSource = BLL.exam_questionsclass.Instance.GetListArray(string.Concat("ExamID=", GetInationID));
            ClassID.DataBind();

            ClassID.Items.Insert(0, new ListItem("默认分类", "0",true));

        }
        override protected void InitModifyCtr()
        {
            BLL.exam_questions.Instance.InitModifyCtr(SID, phCtrList);

        }
        override protected void SaveModel()
        {

            lstOtherColumn.Add(new OtherColumn("AddDateTimeInt", Core.SqlDateTimeInt.GetSecond(DateTime.Now).ToString()));
            lstOtherColumn.Add(new OtherColumn("AddDateTime", DateTime.Now.ToString()));
            lstOtherColumn.Add(new OtherColumn("AddUserID", UserID.ToString()));
            lstOtherColumn.Add(new OtherColumn("AddUserNiName",UserNiname));
           
             lstOtherColumn.Add(new OtherColumn("AnswerJudge", (rbAnswerJudge.SelectedValue == "1").ToString()));


             string Aswersd = "";  // 考试题答案
            for (int i = 0; i < QuestionsType.Items.Count; i++)
            {
                if (QuestionsType.Items[i].Selected == true)
                {
                    string Choice = QuestionsType.Items[i].Value;
                           //存题目类型
                           // lstOtherColumn.Add(new OtherColumn("QuestionsType",Choice));
                   
                    if (Choice=="0")
                    {
                        if (CheckBoxA.Checked)
                        {
                            Aswersd = AswersdA;
                        }
                        if (CheckBoxB.Checked)
                        {
                            Aswersd = AswersdB;
                        }
                        if (CheckBoxC.Checked)
                        {
                            Aswersd = AswersdC;
                        }
                        if (CheckBoxD.Checked)
                        {
                            Aswersd = AswersdD;
                        }
                        if (CheckBoxE.Checked)
                        {
                            Aswersd = AswersdE;
                        }
                        if (CheckBoxF.Checked)
                        {
                            Aswersd = AswersdF;
                        }
                        if (CheckBoxG.Checked)
                        {
                            Aswersd = AswersdG;
                        }
                        if (Aswersd.ToString() == "")
                        {
                            Response.Write("<script language='javascript'>alert('" + "请选择一个答案" + "')</script>");
                            break;
                        }
                        else {
                            lstOtherColumn.Add(new OtherColumn("RightABC", Aswersd));
                        }
                            
                        
                      //
                    
                    }
                   else  if (Choice == "1")
                    {
                        //Response.Write("<script>alert(" + Choice+ ")</script>");
                        if (CheckBoxA.Checked)
                        {   
                            Aswersd+=AswersdA + ",";
                           //  Response.Write("<script>alert('" + Aswersd + "')</script>");
                        }
                        if (CheckBoxB.Checked)
                        {
                            Aswersd += AswersdB + ",";
                        }
                        if (CheckBoxC.Checked)
                        {
                            Aswersd += AswersdC + ",";
                        }
                        if (CheckBoxD.Checked)
                        {
                            Aswersd = Aswersd + AswersdD + ",";
                        }
                        if (CheckBoxE.Checked)
                        {
                            Aswersd = Aswersd + AswersdE + ",";
                        }
                        if (CheckBoxF.Checked)
                        {
                            Aswersd = Aswersd + AswersdF + ",";
                        }
                        if (CheckBoxG.Checked)
                        {
                            Aswersd = Aswersd + AswersdG + ",";
                        }
                        lstOtherColumn.Add(new OtherColumn("RightABC", Aswersd));
                    }
                    // 当选为填空的时候 获得文本框的值
                     // 数据库中缺少文本框的值的列
                    if (QuestionsType.SelectedValue=="2")
                    {
                        Aswersd = Blanks.Text;
                        
                         lstOtherColumn.Add(new OtherColumn("", Aswersd));
                    }
                  //  当选为问答题的时候 要的也是答案解析里面的内容
                    else if (Choice == "3")
                    {
                        //问答题答案
                        //Response.Write("<script>alert('" + Analysis.Text + "')</script>");
                        lstOtherColumn.Add(new OtherColumn("Analysis", Analysis.Text));
                    }
                    // 当选为判断题的时候
                    else if (Choice == "4")
                    {
                        for (int n = 0; n < rbAnswerJudge.Items.Count; n++)
                        {
                            if (rbAnswerJudge.Items[n].Selected == true)
                            {
                                string Judge = rbAnswerJudge.Items[n].Value;

                           // Response.Write("<script>alert('"+Judge+"')</script>");
                           //判断题答案
                            lstOtherColumn.Add(new OtherColumn("rbAnswerJudge", Judge));
                            }
                        }
                    }
                }
            }
         
            lstOtherColumn.Add(new OtherColumn("RightABC",""));
            

            if (GetInationID > 0)
                lstOtherColumn.Add(new OtherColumn("ExamID", GetInationID.ToString()));

            //lstOtherColumn.Add(new OtherColumn("Score", Score.Text));

            BLL.exam_questions.Instance.SaveEntityFromCtr(phCtrList, lstOtherColumn);




        }

        

        

       
    }
}