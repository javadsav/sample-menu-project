import { UtensilsCrossed } from 'lucide-react';

export function Header() {
  return (
    <header className="relative bg-gradient-to-r from-amber-900 via-orange-800 to-amber-900 text-white py-24 overflow-hidden">
      <div className="absolute inset-0 bg-[url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNjAiIGhlaWdodD0iNjAiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGRlZnM+PHBhdHRlcm4gaWQ9ImdyaWQiIHdpZHRoPSI2MCIgaGVpZ2h0PSI2MCIgcGF0dGVyblVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+PHBhdGggZD0iTSAxMCAwIEwgMCAwIDAgMTAiIGZpbGw9Im5vbmUiIHN0cm9rZT0icmdiYSgyNTUsMjU1LDI1NSwwLjEpIiBzdHJva2Utd2lkdGg9IjEiLz48L3BhdHRlcm4+PC9kZWZzPjxyZWN0IHdpZHRoPSIxMDAlIiBoZWlnaHQ9IjEwMCUiIGZpbGw9InVybCgjZ3JpZCkiLz48L3N2Zz4=')] opacity-30"></div>

      <div className="container mx-auto px-4 relative z-10">
        <div className="flex flex-col items-center text-center">
          <div className="mb-6 relative">
            <div className="absolute inset-0 bg-yellow-400 blur-xl opacity-40 rounded-full"></div>
            <UtensilsCrossed size={64} className="relative text-yellow-300 drop-shadow-lg" strokeWidth={1.5} />
          </div>

          <h1 className="text-6xl md:text-7xl font-bold mb-4 tracking-wide">
            <span className="bg-gradient-to-r from-yellow-200 via-yellow-100 to-yellow-200 bg-clip-text text-transparent drop-shadow-lg">
              Golestan
            </span>
          </h1>

          <p className="text-xl md:text-2xl text-yellow-100 font-light tracking-widest mb-2">
            Persian Cuisine
          </p>

          <div className="w-32 h-1 bg-gradient-to-r from-transparent via-yellow-300 to-transparent mt-4"></div>

          <p className="mt-6 text-lg text-yellow-50 max-w-2xl font-light">
            Experience the rich flavors and ancient traditions of Persia
          </p>
        </div>
      </div>

      <div className="absolute bottom-0 left-0 right-0 h-16 bg-gradient-to-t from-stone-50 to-transparent"></div>
    </header>
  );
}
