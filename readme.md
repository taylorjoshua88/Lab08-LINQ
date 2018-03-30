# LinqInManhattan

**Author**: Joshua Taylor
**Version**: 1.0.0

## Overview

LinqInManhattan demonstrates using Language Integrated Querying (LINQ) in C#
in addition to JSON deserialization with the Newtonsoft.Json NuGet package.
Source data has been provided in the form of a minified JSON file called
data.json representing geolocational data across various boroughs and
neighborhoods in New York City. LINQ is used to select the neighborhood
data specifically and to filter out any blank or duplicate results. These
neighborhoods are then printed to the console.

## Getting Started

GenericCollections targets the .NET Core 2.0 platform. The .NET Core 2.0 SDK can
be downloaded from the following URL for Windows, Linux, and macOS:

https://www.microsoft.com/net/download/

The dotnet CLI utility would then be used to build and run the application:

    cd LinqInManhattan
    dotnet build
    dotnet run

Additionally, users can build and run LinqInManhattan using Visual
Studio 2017 or greater by opening the solution file at the root of this
repository. No unit tests were included with this solution.

## Example

#### Unfiltered Neighborhood Query ####
![Unfiltered Query Screenshot](/assets/allScreenshot.JPG)
#### Neighborhood Query Without Empty Results ####
![Non-Empty Query Screenshot](/assets/nonemptyScreenshot.JPG)
#### Neighborhood Query With Only Unique, Non-Empty Results ####
![Unique Non-Empty Query Screenshot](/assets/uniqueNonemptyScreenshot.JPG)

## Architecture

LinqInManhattan makes LINQ queries against generic collections which are
deserialized from geolocation data taken from a provided JSON file, data.json.
Each JavaScript object type in the JSON was translated into C# classes
manually, and then the Newtonsoft.Json NuGet package was used to perform
the deserialization into C# objects of these classes.

### Geometry

_Geometry_ contains a string property called type corresponding to the "type"
field within JSON geometry objects. The payload, "coordinates", is stored in
a double array property called "Coordinates".

### Properties

The _Properties_ class contains the addressing data for each feature within
the JSON data set as C# string properties. *Properties.Neighborhood* is used
by the LINQ queries to select a list of all of the neighborhoods represented
by the features included in the dataset.

### Feature

The _Feature_ class is used to deserialize feature objects from the JSON
dataset. The type field is included as a string property in addition to
_Geometry_ and _Properties_ properties.

### FeatureCollection

_FeatureCollection_ is a C# class corresponding to the "FeatureCollection"
JSON root object. _FeatureCollection_ implements the _IList\<Feature\>_
interface and supports LINQ queries against it. This implementation is provided
through the "Features" property of type _List\<Feature\>_

#### Queries ####

Some queries have been added to the _FeatureCollection_ class as pre-made LINQ
queries for _FeatureCollection_ objects to execute. These include an unfiltered neighborhood query which returns all _Feature.Neighborhood_ properties from
the _FeatureCollection.Features_ list regardless of whether they are empty
or duplicate entries. In addition, a query which removes empty strings as well
as one that eliminates duplicates are provided. Finally, the
_FeatureCollection.GetAllUniqueNonEmptyNeighborhoodsConsolidated()_ performs
the non-empty, unique neighborhood query as a single LINQ query rather than
a cumulative series of subqueries.

### Data Model

The source data for this program is stored in an external data.json file which
consists of the aforementioned JavaScript objects grouped by _Feature_ objects
as an array within the root _FeatureCollection_ object. This JSON file is
deserialized using Newtonsoft.Json into native C# class objects from the
JSON root up through its descendent objects, stored as key/value pairs in
JSON. The deserialized objects are stored on the heap and are queried against
without any changes being made or any serialization being performed back
to data.json or any other persistent data store.

### Command Line Interface (CLI)

LinqInManhattan uses a command line interface through the user's console
environment. Each query result is displayed to the users across two columns,
and the results are paginated for ease of reading. Between each page is a
prompt for the user to press a key to continue to either the next page of
results or to the first page of the next query. A short description of each
query is provided at the top of the first page of results.

## Change Log

* 3.29.2018 [Joshua Taylor](mailto:taylor.joshua88@gmail.com) - Initial
release. All tests are passing.