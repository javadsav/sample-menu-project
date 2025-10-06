import { useState, useEffect } from 'react';
import { supabase, Category, MenuItem } from '../lib/supabase';

export function useMenu() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [menuItems, setMenuItems] = useState<MenuItem[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    async function fetchMenu() {
      try {
        const [categoriesResult, menuItemsResult] = await Promise.all([
          supabase
            .from('categories')
            .select('*')
            .order('display_order'),
          supabase
            .from('menu_items')
            .select('*')
            .order('created_at')
        ]);

        if (categoriesResult.error) throw categoriesResult.error;
        if (menuItemsResult.error) throw menuItemsResult.error;

        setCategories(categoriesResult.data || []);
        setMenuItems(menuItemsResult.data || []);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Failed to load menu');
      } finally {
        setLoading(false);
      }
    }

    fetchMenu();
  }, []);

  return { categories, menuItems, loading, error };
}
