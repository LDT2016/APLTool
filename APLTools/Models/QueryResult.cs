using System;
using System.Collections.Generic;

namespace APLTools.Models
{
    /// <summary>
    /// QueryResult object
    /// </summary>
    
    public class QueryResult
    {
        /// <summary>
        /// indicates if the query is successful
        /// </summary>
        
        public bool Success { get; set; }

        /// <summary>
        /// the number of the returned query results
        /// </summary>
        
        public int Results { get; set; }

        /// <summary>
        /// the total number of the query results
        /// </summary>
        
        public int Total { get; set; }

        /// <summary>
        /// result offset
        /// </summary>
        
        public int Offset { get; set; }

        /// <summary>
        /// details of the query results
        /// </summary>
        
        public List<QueryHit> Hits { get; set; }
    }

    /// <summary>
    /// QueryHit object
    /// </summary>
    
    public class QueryHit
    {
        /// <summary>
        /// the path of the node
        /// </summary>
        
        public string Path { get; set; }

        /// <summary>
        /// excerpt
        /// </summary>
        
        public string Excerpt { get; set; }

        /// <summary>
        /// node name
        /// </summary>
        
        public string Name { get; set; }

        /// <summary>
        /// node title
        /// </summary>
        
        public string Title { get; set; }

        /// <summary>
        /// last modified date time
        /// </summary>
        
        public DateTime LastModified { get; set; }
    }
}
