export const useGetSettings = () => {
    const getBaseUrl = () => `/${window.location.pathname.split('/')[1]}/api`;

    return { getBaseUrl };
};