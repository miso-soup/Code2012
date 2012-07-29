using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miso.Code2012.Model.Answers
{
    /// <summary>
    /// 回答のリポジトリ
    /// </summary>
    public interface IAnswerRepository
    {
        /// <summary>
        /// すべて取得します
        /// </summary>
        /// <returns></returns>
        IEnumerable<Answer> FindAll();
    }
}
