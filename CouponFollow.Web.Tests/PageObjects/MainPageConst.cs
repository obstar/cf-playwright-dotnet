namespace CouponFollow.Web.Tests.PageObjects;

public static class MainPageConst
{
    public static class Selectors
    {
        public const string StaffPicks = "div.staff-picks [data-domain]";
        public const string TodaysTopCoupons = ".swiper-wrapper div:not(.swiper-slide-duplicate)";
        public const string TodaysTrendingCoupons = ".trending-deals.cont > article";
        public const string TopDealsSwiper = ".big-cont.top-deals-swiper";
    }

    public static class Text
    {
        public const string Title = "Coupon Codes in Real-Time - CouponFollow";
    }
}