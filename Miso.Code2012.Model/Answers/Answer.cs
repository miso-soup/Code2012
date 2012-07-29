using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Miso.Code2012.Model.Answers
{
    /// <summary>
    /// 回答
    /// </summary>
    public class Answer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// 回答を投稿したアプリの名前
        /// </summary>
        [JsonProperty("app_name")]
        public String AppName { get; set; }

        /// <summary>
        /// 投稿日
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreationDate { get; set; }
        
        /// <summary>
        /// 得意な・主な活躍場所の言語やプラットフォーム
        /// </summary>
        [JsonProperty("languages")]
        public String Languages { get; set; }

        /// <summary>
        /// 都道府県名や国名
        /// </summary>
        [JsonProperty("locale")]
        public String Locale { get; set; }

        /// <summary>
        /// コード歴
        /// </summary>
        [JsonProperty("how_year")]
        public int? HowYear { get; set; }

        /// <summary>
        /// フリーコメント
        /// </summary>
        [JsonProperty("free_comment")]
        public String FreeComment { get; set; }

        /// <summary>
        /// なぜコードをかくのかの元の値
        /// </summary>
        [JsonProperty("why")]
        public String WhyValue { get; set; }

        /// <summary>
        /// なぜコードをかくのか
        /// </summary>
        public WhyWriteCode Why
        {
            get { return WhyWriteCode.GetBy(this.WhyValue); }
        }

        /// <summary>
        /// なぜコードをかくのかの理由
        /// </summary>
        [JsonProperty("why_reasons")]
        public IEnumerable<String> WhyReasons
        {
            get { return Why.Reasons; }
        }
    }    

    [TestFixture]
    public class AnswerTest
    {
        /// <summary>
        /// WhyWriteCodeオブジェクトのReasonsテスト
        /// </summary>
        [Test]
        public void Why_Test()
        {
            {
                var answer = new Answer();
                answer.WhyValue = "invalid";
                
                Assert.IsFalse(answer.Why.Reasons.Any());
            }
            {
                var answer = new Answer();
                answer.WhyValue = "true,false";
                WhyWriteCode actual = answer.Why;

                Assert.AreEqual(WhyWriteCode.ToEnjoy, answer.Why.Reasons.Single());
            }
            {
                var answer = new Answer();
                answer.WhyValue = "true,invalidValue,true";
                WhyWriteCode actual = answer.Why;

                Assert.AreEqual(WhyWriteCode.ToEnjoy, answer.Why.Reasons.ElementAt(0));
                Assert.AreEqual(WhyWriteCode.ToSolve, answer.Why.Reasons.ElementAt(1));
            }
            {
                var answer = new Answer();
                answer.WhyValue = "[true,true,true,false,true]";
                WhyWriteCode actual = answer.Why;

                Assert.AreEqual(WhyWriteCode.ToEnjoy, answer.Why.Reasons.ElementAt(0));
                Assert.AreEqual(WhyWriteCode.ToFunny, answer.Why.Reasons.ElementAt(1));
                Assert.AreEqual(WhyWriteCode.ToSolve, answer.Why.Reasons.ElementAt(2));
                Assert.AreEqual(WhyWriteCode.Necessity, answer.Why.Reasons.ElementAt(3));
            }
            {
                var answer = new Answer();
                answer.WhyValue = "true,true,true,true,true,true";
                WhyWriteCode actual = answer.Why;

                Assert.AreEqual(WhyWriteCode.ToEnjoy, answer.Why.Reasons.ElementAt(0));
                Assert.AreEqual(WhyWriteCode.ToFunny, answer.Why.Reasons.ElementAt(1));
                Assert.AreEqual(WhyWriteCode.ToSolve, answer.Why.Reasons.ElementAt(2));
                Assert.AreEqual(WhyWriteCode.SoWeak, answer.Why.Reasons.ElementAt(3));
                Assert.AreEqual(WhyWriteCode.Necessity, answer.Why.Reasons.ElementAt(4));
                Assert.AreEqual(WhyWriteCode.ToMoney, answer.Why.Reasons.ElementAt(5));
            }
        }
    }
}
