import { createAsyncThunk } from "@reduxjs/toolkit"

interface MyData {
    // ...
}

const fetchUserById = createAsyncThunk(
    'weatherforecast',
    // Declare the type your function argument here:
    async () => {
        const response = await fetch(`weatherforecast`)
        // Inferred return type: Promise<MyData>
        return (await response.json()) as MyData
    }
)


export default fetchUserById