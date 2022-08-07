//require('dotenv').config({ path: `.env.${process.env.NODE_ENV ?? 'development'}` })

export const useGetSettings = () => {
    //console.log('Env: ', process.env.NODE_ENV)
    const getBaseUrl = () => "http://localhost:5080/api"

    return { getBaseUrl };
};