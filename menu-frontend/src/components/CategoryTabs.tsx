import { Category } from '../lib/supabase';
import { Soup, Flame, CookingPot, Wheat, CakeSlice } from 'lucide-react';

interface CategoryTabsProps {
  categories: Category[];
  activeCategory: string;
  onCategoryChange: (categoryId: string) => void;
}

const iconMap: Record<string, React.ComponentType<{ size?: number; className?: string }>> = {
  'soup': Soup,
  'flame': Flame,
  'cooking-pot': CookingPot,
  'wheat': Wheat,
  'cake-slice': CakeSlice,
};

export function CategoryTabs({ categories, activeCategory, onCategoryChange }: CategoryTabsProps) {
  return (
    <div className="bg-white shadow-sm border-b border-amber-100 sticky top-0 z-40">
      <div className="container mx-auto px-4">
        <div className="flex overflow-x-auto scrollbar-hide gap-2 py-6">
          {categories.map((category) => {
            const Icon = iconMap[category.icon] || Soup;
            const isActive = activeCategory === category.id;

            return (
              <button
                key={category.id}
                onClick={() => onCategoryChange(category.id)}
                className={`
                  flex items-center gap-3 px-6 py-3 rounded-lg font-medium transition-all duration-300 whitespace-nowrap
                  ${isActive
                    ? 'bg-gradient-to-r from-amber-600 to-orange-600 text-white shadow-lg scale-105'
                    : 'bg-stone-100 text-gray-700 hover:bg-amber-50 hover:text-amber-700 hover:shadow'
                  }
                `}
              >
                <Icon size={20} />
                <span className="text-lg">{category.name}</span>
              </button>
            );
          })}
        </div>
      </div>
    </div>
  );
}
