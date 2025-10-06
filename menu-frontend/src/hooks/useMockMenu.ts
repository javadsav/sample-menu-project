// mock/useMenuMock.ts
import { Category, MenuItem } from '../lib/supabase';

export function useMenu() {
  const categories: Category[] = [
    {
      id: '1',
      name: 'Appetizers',
      display_order: 1,
      icon: '🥗',
      created_at: '2025-10-01T12:00:00Z',
    },
    {
      id: '2',
      name: 'Main Courses',
      display_order: 2,
      icon: '🍝',
      created_at: '2025-10-01T12:05:00Z',
    },
    {
      id: '3',
      name: 'Desserts',
      display_order: 3,
      icon: '🍰',
      created_at: '2025-10-01T12:10:00Z',
    },
    {
      id: '4',
      name: 'Drinks',
      display_order: 4,
      icon: '🥤',
      created_at: '2025-10-01T12:15:00Z',
    },
  ];

  const menuItems: MenuItem[] = [
    {
      id: '101',
      category_id: '1',
      name: 'Bruschetta',
      description: 'Toasted bread topped with fresh tomatoes, garlic, and basil.',
      price: 7.5,
      image_url: '/images/bruschetta.jpg',
      is_vegetarian: true,
      is_popular: true,
      created_at: '2025-10-02T10:00:00Z',
    },
    {
      id: '102',
      category_id: '1',
      name: 'Stuffed Mushrooms',
      description: 'Baked mushrooms filled with herbs and cheese.',
      price: 8.0,
      image_url: '/images/stuffed_mushrooms.jpg',
      is_vegetarian: true,
      is_popular: false,
      created_at: '2025-10-02T10:05:00Z',
    },
    {
      id: '201',
      category_id: '2',
      name: 'Grilled Salmon',
      description: 'Fresh salmon served with lemon butter sauce.',
      price: 18.99,
      image_url: '/images/salmon.jpg',
      is_vegetarian: false,
      is_popular: true,
      created_at: '2025-10-02T10:10:00Z',
    },
    {
      id: '202',
      category_id: '2',
      name: 'Pasta Alfredo',
      description: 'Creamy pasta with parmesan cheese and mushrooms.',
      price: 14.5,
      image_url: '/images/pasta_alfredo.jpg',
      is_vegetarian: true,
      is_popular: false,
      created_at: '2025-10-02T10:15:00Z',
    },
    {
      id: '301',
      category_id: '3',
      name: 'Chocolate Lava Cake',
      description: 'Warm chocolate cake with molten chocolate center.',
      price: 9.0,
      image_url: '/images/lava_cake.jpg',
      is_vegetarian: true,
      is_popular: true,
      created_at: '2025-10-02T10:20:00Z',
    },
    {
      id: '401',
      category_id: '4',
      name: 'Iced Latte',
      description: 'Chilled espresso with milk and ice.',
      price: 5.5,
      image_url: '/images/iced_latte.jpg',
      is_vegetarian: true,
      is_popular: true,
      created_at: '2025-10-02T10:25:00Z',
    },
  ];

  const loading = false;
  const error = null;

  return { categories, menuItems, loading, error };
}
