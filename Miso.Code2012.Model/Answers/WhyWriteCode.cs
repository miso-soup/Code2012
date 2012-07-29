using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miso.Code2012.Model.Answers
{
    /// <summary>
    /// なぜコードをかくのか
    /// </summary>
    public class WhyWriteCode
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WhyWriteCode()
        { 
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="values">理由を表す値</param>
        public WhyWriteCode(IEnumerable<Boolean> values)
        {
            if (values == null)
                throw new ArgumentNullException();

            _values = values;
        }

        /// <summary>
        /// 理由を表す値
        /// </summary>
        private IEnumerable<Boolean> _values = new List<Boolean>();

        /// <summary>
        /// 理由
        /// </summary>
        public IEnumerable<String> Reasons
        {
            get { return getReasons(); }
        }

        /// <summary>
        /// 理由を表す値
        /// </summary>
        /// <remarks>すべての理由に対する値を取得します</remarks>
        public IEnumerable<Boolean> Values
        {
            get
            {
                var myReasons = this.Reasons;

                return _allReasons
                    .Select(e => myReasons.Contains(e))
                    .ToList();
            }
        }

        /// <summary>
        /// 考えられるすべての理由を取得します。
        /// </summary>
        public IEnumerable<String> AllReasons
        {
            get { return _allReasons; }
        }

        /// <summary>
        /// 理由を取得します
        /// </summary>
        /// <returns></returns>
        private IEnumerable<String> getReasons()
        {
            var results = new List<String>();
            
            int index = 0;
            foreach (bool value in _values)
            {
                if (value)
                    results.Add(_allReasons.ElementAt(index));

                index++;
            }

            return results;
        }

        /// <summary>
        /// 理由を表す文字列より、なぜコードを書くのかを取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WhyWriteCode GetBy(string value)
        {
            if (String.IsNullOrEmpty(value))
                return new WhyWriteCode();

            value = value
                .Replace("[", String.Empty)
                .Replace("]", String.Empty);

            List<String> values = value.Split(new Char[] { ',' }).ToList();

            return new WhyWriteCode(values.Select(e => ToWhyValue(e)));
        }

        /// <summary>
        /// 文字列より、Booleanの値を取得します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns>不正な文字の場合は、falseを返します。</returns>
        private static bool ToWhyValue(String value)
        {
            bool result = false;

            Boolean.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// 考えられるすべての理由
        /// </summary>
        private IEnumerable<String> _allReasons = new List<String>()
        {
            ToEnjoy,
            ToFunny,
            ToSolve,
            SoWeak,
            Necessity,
            ToMoney
        };

        public static String ToEnjoy = "創造する楽しみ・喜びのために";
        public static String ToFunny = "書いた結果がすぐに動き出すのがおもしろい";
        public static String ToSolve = "パズルを解くような楽しみ、問題を解く喜びがあるから";
        public static String SoWeak = "人間相手が苦手なので(!?)";
        public static String Necessity = "必要に迫られて";
        public static String ToMoney = "稼ぐために";
    }
}
