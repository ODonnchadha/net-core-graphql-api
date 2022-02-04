import React from "react";
import { useQuery, gql } from "@apollo/client";

const GET_COURSES = gql`
        query getCourses {
	        courses {
                id
		        name
		        description
		        reviews {
                    id
                    rate
                    comment
                }
		        dateAdded
                dateUpdated
            }
        }
`;

function SoftwareDriver() {
    const { data, loading, error } = useQuery(GET_COURSES);

    if (loading) {
        return <div>loading</div>;
    }
    
    if (error) {
        return <div>{error}</div>;
    }

    return data.courses.map(({ id, name, description, reviews }) => (
            <div key={id} style={{padding:2}}>
                <p>
                    {id}: {name} {description}
                </p>
                <p>
                    {
                        reviews.map((r) => (
                            <span key={r.id} style={{padding:2}}>
                                <span>{r.rate}</span>
                                <span>{r.comment}</span>
                            </span>
                        ))
                    }
                </p>
            </div>
        ));
    }
export default SoftwareDriver;