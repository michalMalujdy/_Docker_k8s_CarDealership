export const useGetSettings = () => {
    const getBaseUrl = () => process.env.REACT_APP_API_BASE_URL;

    return { getBaseUrl };
};