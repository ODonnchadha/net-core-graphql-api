import { ApolloClient, ApolloLink, InMemoryCache } from "@apollo/client";
import { HttpLink } from "@apollo/client";

const httpLink = new HttpLink({
    uri: "https://localhost:44333/graphql"
});

export const client = new ApolloClient({
    cache: new InMemoryCache(),
    link: ApolloLink.from([httpLink]),
    fetchOptions: {
        mode: 'no-cors'
      }
});