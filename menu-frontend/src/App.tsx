import { useState, useMemo, useEffect } from "react";
import { Header } from "./components/Header";
import { CategoryTabs } from "./components/CategoryTabs";
import { MenuCard } from "./components/MenuCard";
import { useMenu } from "./hooks/useMockMenu";
import { Loader2 } from "lucide-react";
import { getAllFoods } from "./lib/api/food";

function App() {
  const { categories, menuItems, loading, error } = useMenu();
  const [activeCategory, setActiveCategory] = useState<string>("");
  const [javadFoods, setJavadFoods] = useState<any[]>([]);
  const [javadLoading, setJavadLoading] = useState(false);
  const [javadError, setJavadError] = useState<string | null>(null);

  // fetch Javad's foods when "Javad" tab is selected
  useEffect(() => {
    async function fetchJavadFoods() {
      if (activeCategory !== "javad") return;
      setJavadLoading(true);
      setJavadError(null);
      try {
        const res = await getAllFoods();
        setJavadFoods(res);
      } catch (err) {
        setJavadError("Failed to fetch Javad’s foods");
      } finally {
        setJavadLoading(false);
      }
    }
    fetchJavadFoods();
  }, [activeCategory]);

  const extendedCategories = [
    ...categories,
    {
      id: "javad",
      name: "Javad",
      display_order: categories.length + 1,
      icon: "🍛",
      created_at: new Date().toISOString(),
    },
  ];

  const filteredMenuItems = useMemo(() => {
    if (!activeCategory || !categories.length) return menuItems;
    return menuItems.filter((item) => item.category_id === activeCategory);
  }, [activeCategory, menuItems, categories]);

  if (!activeCategory && categories.length > 0) {
    setActiveCategory(categories[0].id);
  }

  if (loading) {
    return (
      <div className="min-h-screen bg-stone-50 flex items-center justify-center">
        <div className="text-center">
          <Loader2 className="w-12 h-12 text-amber-600 animate-spin mx-auto mb-4" />
          <p className="text-gray-600 text-lg">Loading menu...</p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="min-h-screen bg-stone-50 flex items-center justify-center">
        <div className="text-center max-w-md bg-white p-8 rounded-lg shadow-lg">
          <p className="text-red-600 text-lg mb-4">Unable to load menu</p>
          <p className="text-gray-600 text-sm">{error}</p>
        </div>
      </div>
    );
  }

  if (categories.length === 0) {
    return (
      <div className="min-h-screen bg-stone-50">
        <Header />
        <div className="container mx-auto px-4 py-12 text-center">
          <p className="text-gray-600 text-lg">Menu coming soon...</p>
        </div>
      </div>
    );
  }

  const activeCategoryName =
    categories.find((cat) => cat.id === activeCategory)?.name || "";

  return (
    <div className="min-h-screen bg-stone-50">
      <Header />

      <CategoryTabs
        categories={extendedCategories}
        activeCategory={activeCategory}
        onCategoryChange={setActiveCategory}
      />

      <main className="container mx-auto px-4 py-12">
        <div className="mb-8">
          <h2 className="text-4xl font-bold text-gray-800 mb-2">
            {activeCategoryName}
          </h2>
          <div className="w-24 h-1 bg-gradient-to-r from-amber-600 to-orange-600"></div>
        </div>

        {activeCategory === "javad" ? (
          <>
            {javadLoading ? (
              <div className="text-center py-12">
                <Loader2 className="w-10 h-10 text-amber-600 animate-spin mx-auto mb-3" />
                <p className="text-gray-600">Loading Javad’s foods...</p>
              </div>
            ) : javadError ? (
              <div className="text-center py-12">
                <p className="text-red-600">{javadError}</p>
              </div>
            ) : javadFoods.length === 0 ? (
              <div className="text-center py-12 text-gray-500">
                No foods available from Javad’s API
              </div>
            ) : (
              <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
                {javadFoods.map((food) => (
                  <div
                    key={food.id}
                    className="bg-white rounded-2xl shadow-md p-6 hover:shadow-lg transition-shadow"
                  >
                    <h3 className="text-xl font-semibold text-gray-800">
                      {food.name}
                    </h3>
                    <p className="text-amber-700 font-medium mt-2">
                      ${food.price?.toFixed(2)}
                    </p>
                    <p className="text-gray-500 text-sm mt-1">
                      Category ID: {food.categoryId}
                    </p>
                  </div>
                ))}
              </div>
            )}
          </>
        ) : filteredMenuItems.length === 0 ? (
          <div className="text-center py-12">
            <p className="text-gray-500 text-lg">
              No items available in this category
            </p>
          </div>
        ) : (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            {filteredMenuItems.map((item) => (
              <MenuCard key={item.id} item={item} />
            ))}
          </div>
        )}
      </main>

      <footer className="bg-gradient-to-r from-amber-900 via-orange-800 to-amber-900 text-white py-12 mt-20">
        <div className="container mx-auto px-4 text-center">
          <div className="mb-4">
            <h3 className="text-2xl font-bold text-yellow-200 mb-2">
              Golestan
            </h3>
            <p className="text-yellow-100 text-sm tracking-widest">
              PERSIAN CUISINE
            </p>
          </div>

          <div className="w-32 h-px bg-gradient-to-r from-transparent via-yellow-300 to-transparent mx-auto my-6"></div>

          <div className="text-yellow-100 text-sm space-y-2">
            <p>123 Heritage Lane, Cultural District</p>
            <p>Reservations: (555) 123-4567</p>
            <p className="mt-4">Open Daily: 11:00 AM - 10:00 PM</p>
          </div>

          <p className="text-yellow-200 text-xs mt-8">
            © 2025 Golestan Restaurant. All rights reserved.
          </p>
        </div>
      </footer>
    </div>
  );
}

export default App;
