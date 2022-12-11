export const useGetSettings = () => {
    const getBaseUrl = () => {
        const tenant = window.location.pathname.split('/')[1];

        if (tenant) {
            return `${process.env.REACT_APP_API_BASE_URL}/${tenant}/api`;
        }

        return `${process.env.REACT_APP_API_BASE_URL}/demo/api`;
    };

    return { getBaseUrl };
};