import { MenuItem } from '../lib/supabase';
import { Leaf, Flame } from 'lucide-react';

interface MenuCardProps {
  item: MenuItem;
}

export function MenuCard({ item }: MenuCardProps) {
  return (
    <div className="group bg-white rounded-lg shadow-md hover:shadow-xl transition-all duration-300 overflow-hidden border border-amber-100 hover:border-amber-300">
      <div className="relative h-48 bg-gradient-to-br from-amber-50 to-orange-50 overflow-hidden">
        <div className="absolute inset-0 bg-[url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+PGNpcmNsZSBjeD0iMiIgY3k9IjIiIHI9IjEiIGZpbGw9InJnYmEoMjUxLDE5MSwzNiwwLjEpIi8+PC9zdmc+')] opacity-40"></div>

        {item.is_popular && (
          <div className="absolute top-3 right-3 bg-gradient-to-r from-red-600 to-orange-600 text-white px-3 py-1 rounded-full text-xs font-semibold flex items-center gap-1 shadow-lg">
            <Flame size={12} />
            Popular
          </div>
        )}

        {item.is_vegetarian && (
          <div className="absolute top-3 left-3 bg-green-600 text-white p-2 rounded-full shadow-lg">
            <Leaf size={16} />
          </div>
        )}

        <div className="absolute inset-0 flex items-center justify-center">
          <div className="text-6xl opacity-20 group-hover:opacity-30 transition-opacity">
            🍽️
          </div>
        </div>
      </div>

      <div className="p-6">
        <div className="flex justify-between items-start mb-3">
          <h3 className="text-xl font-semibold text-gray-800 group-hover:text-amber-700 transition-colors">
            {item.name}
          </h3>
          <span className="text-xl font-bold text-amber-700 ml-4 whitespace-nowrap">
            ${item.price.toFixed(2)}
          </span>
        </div>

        <p className="text-gray-600 text-sm leading-relaxed">
          {item.description}
        </p>

        <div className="mt-4 flex gap-2">
          {item.is_vegetarian && (
            <span className="text-xs bg-green-100 text-green-700 px-2 py-1 rounded-full">
              Vegetarian
            </span>
          )}
        </div>
      </div>
    </div>
  );
}
