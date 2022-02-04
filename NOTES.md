## ASP.NET Core: Building A GraphQL API
- Linked-In Learning by Ervis Trupja

- INTRODUCTION:
    - REST API. Overfetching.
    - GraphQL: Specify exact data. Easily aggreggate via multiple sources. Use a type system via schema.

- GETTING STARTED:
    - REST & GraphQL: Two API design approaches that fulfill the same function: data transmition via Internet protocols such as HTTP.
    - .NET Web API Project Overview.
        ```javascript
            Add-Migration INIT
            Update-Database
        ```
    - Setting up GrapghQL:
        - NUGET packages:

- DATA QUERYING IN .NET WEB API:
    - Operations: Query. Mutation. (A write, followed by a fetch.) Subscription: Long-lived request that fetches data in response to source events.
    - Types in GraphQL:
        1. Basic types: float, integer.
        2. Object types: ExampleObject { id: Int }
        ```javascript
            query {
                courses {
                    name
                    description
                    review
                    dateAdded
                },
                firstCourse: course (id: 1) {
                    id
                    name
                }
                secondCourse: course (id: 2) {
                    name
                    description
                    review
                }
            }
        ```

- DATA MUTATION WITH GRAPHQL IN .NET WEB API:
    - Mutation: Data manipulation. Create, Update, Delete. Modify data in a data store and return a value.
    ```javascript
        mutation {
            createCourse(course: {
                name: "Course On Mutations",
                description: "A decent description",
                review: 2,
                dateAdded: "2022-02-02T19:00:14.6150796Z",
                dateUpdated: "2022-02-02T19:00:14.6150796Z"
            }) {
                id
            }
        }
        mutation {
            updateCourse(id: 2, course: {
                name: "Second Course Updated",
                description: "A decent description has been updated",
                review: 1,
                dateUpdated: "2022-02-02T19:21:56.8311986Z"
            }) {
                id
            }
        }
        mutation {
            deleteCourse(id: 2) {
                id
            }
        }
    ```

- QUERYING & MUTATING RELATIONAL DATA WITH GRAPHQL IN .NET WEB API:
    - Notes:[Swagger](https://localhost:44333/swagger/index.html) [GraphQL](https://localhost:44333/ui/graphql)
    - Adding relational data:
    ```
        query {
	        courses {
                id
		        name
		        description
		        reviews {
                    rate
                    comment
                }
		        dateAdded
                dateUpdated
            }
        }
        mutation{
          createCourse(course: {
            name: "GraphQL Course With Relational Data",
            description: "createCourse",
            dateAdded: "2022-02-02T21:51:10.7654242Z",
            dateUpdated: "2022-02-02T21:51:10.7654242Z",
            reviews: [
              {
                rate: 0,
                comment: "Terrible"
              },
			        {
                rate: 2,
                comment: "Decent"
              },
            ]
          }) {
            id
            name,
            reviews {
              id
              comment
            }
          }
        }
    ```