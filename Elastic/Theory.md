## Elasticsearch terms
- Document
- Index  
- Cluster
- Node
- Type
- Shard/Replica

## Data Types
- binary

Binary value encoded as a Base64 string.

- boolean

true and false values.

- Keywords

The keyword family, including keyword, constant_keyword, and wildcard.

- Numbers

Numeric types, such as long and double, used to express amounts.

- Dates

Date types, including date and date_nanos.

- alias

Defines an alias for an existing field.
### Objects and relational types
- object

A JSON object.

- flattened

An entire JSON object as a single field value.

- nested

A JSON object that preserves the relationship between its subfields.

- join

Defines a parent/child relationship for documents in the same index.

### Structured data types
- Range

Range types, such as long_range, double_range, date_range, and ip_range.

- ip

IPv4 and IPv6 addresses.

- version

Software versions. Supports Semantic Versioning precedence rules.
- murmur3

Compute and stores hashes of values.
### Aggregate data types

- aggregate_metric_double

Pre-aggregated metric values.

- histogram

Pre-aggregated numerical values in the form of a histogram.

### Text search types

- text

Analyzed, unstructured text.

- annotated-text

Text containing special markup. Used for identifying named entities.

- completion

Used for auto-complete suggestions.

- search_as_you_type
text-like type for as-you-type completion.

- token_count
A count of tokens in a text.

### Document ranking types
- dense_vector

Records dense vectors of float values.

- sparse_vector

Records sparse vectors of float values.

- rank_feature

Records a numeric feature to boost hits at query time.

- rank_features

Records numeric features to boost hits at query time.

### Spatial data types
- geo_point

Latitude and longitude points.

- geo_shape

Complex shapes, such as polygons.

- point

Arbitrary cartesian points.

- shape

Arbitrary cartesian geometries.

### Other types
- percolator

Indexes queries written in Query DSL.
