﻿#region MIT license
////////////////////////////////////////////////////////////////////
// MIT license:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//
// Authors:
//        Andrus Moor
////////////////////////////////////////////////////////////////////
#endregion

using System.Collections.Generic;

namespace DbLinq.Linq
{

    public sealed class ChangeSet
    {

        readonly DataContext _dataContext;

        internal ChangeSet(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<object> Deletes
        {
            get
            {
                List<object> list = new List<object>();
                foreach (IMTable tbl in _dataContext._tableList)
                {
                    list.AddRange(tbl.Deletes);
                }
                return list;
            }
        }

        public IList<object> Inserts
        {
            get
            {
                List<object> list = new List<object>();
                foreach (IMTable tbl in _dataContext._tableList)
                {
                    list.AddRange(tbl.Inserts);
                }
                return list;
            }
        }

        public IList<object> Updates
        {
            get
            {
                List<object> list = new List<object>();
                foreach (IMTable tbl in _dataContext._tableList)
                {
                    list.AddRange(tbl.Updates);
                }
                return list;
            }
        }

        public override string ToString()
        {
            return string.Format("Total changes: {{Added: {0}, Removed: {1}, Modified: {2} }}",
              Inserts.Count, Deletes.Count, Updates.Count);
        }
    };
}