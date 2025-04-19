<h1 align="center">🧩 Rubik's Cube Simulator</h1>

<p align="center">
  A full-stack Rubik’s Cube simulator with a clean API backend and a modern frontend UI.
</p>

<hr/>

## 🚀 Getting Started

### 📦 Prerequisites

#### 🔧 Backend (.NET 9)

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

#### 🌐 Frontend

- [Node.js](https://nodejs.org/) **v22.14.0**
- [pnpm](https://pnpm.io/)

🧰 Setup Guide<br>
📦 Install pnpm<br>
Make sure pnpm is installed globally:

npm install -g pnpm

<details> <summary>💡 Node version management</summary> Use [nvm](https://github.com/nvm-sh/nvm) or [fnm](https://github.com/Schniz/fnm) to easily manage Node.js versions. </details>

🔙 Backend – ASP.NET Core<br>
🧪 Run Locally<br>
cd RubiksCube.API<br>
dotnet run<br>
📍 The API will be available at:

http://localhost:5272

🎨 Frontend – React + pnpm + vite<br>
💡 Ensure you're using Node.js v22.14.0 and pnpm is installed globally.

📦 Install Dependencies<br>
cd RubiksCubeFE<br>
pnpm install

▶️ Start Development Server<br>
pnpm dev<br>
🌍 The frontend will run at: http://localhost:5173

📁 Project Structure<br>
/RubiksCube.API # ASP.NET Core backend<br>
/RubiksCube.Application # Application layer logic<br>
/RubiksCube.Domain # Domain models and logic<br>
/RubiksCubeFE # Frontend project (React, etc.)<br>
README.md # You're here :)

💡 Notes<br>
The frontend must be configured to call the backend at http://localhost:5272.<br>
CORS should be enabled in the backend to allow requests from the frontend.
