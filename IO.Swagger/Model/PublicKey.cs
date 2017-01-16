/* 
 * Provider server
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IO.Swagger.Model
{
    /// <summary>
    /// An object to hold the publickey
    /// </summary>
    [DataContract]
    public partial class PublicKey :  IEquatable<PublicKey>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublicKey" /> class.
        /// </summary>
        /// <param name="N">N.</param>
        /// <param name="E">E.</param>
        public PublicKey(string N = null, string E = null)
        {
            this.N = N;
            this.E = E;
        }
        
        /// <summary>
        /// Gets or Sets N
        /// </summary>
        [DataMember(Name="n", EmitDefaultValue=false)]
        public string N { get; set; }
        /// <summary>
        /// Gets or Sets E
        /// </summary>
        [DataMember(Name="e", EmitDefaultValue=false)]
        public string E { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PublicKey {\n");
            sb.Append("  N: ").Append(N).Append("\n");
            sb.Append("  E: ").Append(E).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as PublicKey);
        }

        /// <summary>
        /// Returns true if PublicKey instances are equal
        /// </summary>
        /// <param name="other">Instance of PublicKey to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PublicKey other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.N == other.N ||
                    this.N != null &&
                    this.N.Equals(other.N)
                ) && 
                (
                    this.E == other.E ||
                    this.E != null &&
                    this.E.Equals(other.E)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.N != null)
                    hash = hash * 59 + this.N.GetHashCode();
                if (this.E != null)
                    hash = hash * 59 + this.E.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
